using FinTransactAPI.Model;
using FinTransactAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinTransactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountInformationController : ControllerBase
    {
        private readonly IAccountInformationRepository _accountInformationRepository;
          
        public AccountInformationController(IAccountInformationRepository accountInformationRepository)
        {
            _accountInformationRepository = accountInformationRepository;
        }

        [Authorize]               
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountInformation>>> GetAccountInformation()
        {
            var accountInformation = await _accountInformationRepository.GetAllAsync();
            return Ok(accountInformation);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountInformation>> GetAccountInformation(int id)
        {
            var accountInformation = await _accountInformationRepository.GetByIdAsync(id);
            if (accountInformation == null)
            {
                return NotFound();
            }
            return Ok(accountInformation);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<AccountInformation>> PostAccountInformation(AccountInformation accountInformation)
        {
            var newAccountInformation = await _accountInformationRepository.AddAsync(accountInformation);
            return CreatedAtAction(nameof(GetAccountInformation), new { id = newAccountInformation.AccountInformationId }, newAccountInformation);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountInformation(int id, AccountInformation accountInformation)
        {
            if (id != accountInformation.AccountInformationId)
            {
                return BadRequest();
            }

            await _accountInformationRepository.UpdateAsync(accountInformation);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountInformation(int id)
        {
            var success = await _accountInformationRepository.DeleteAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
 